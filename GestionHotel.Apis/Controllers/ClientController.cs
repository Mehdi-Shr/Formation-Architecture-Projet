public class ClientsController : BaseController
{
    private readonly IClientRepository _clientRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IPaiementService _paiementService;

    public ClientsController(IClientRepository clientRepository, IReservationRepository reservationRepository, IPaiementService paiementService)
    {
        _clientRepository = clientRepository;
        _reservationRepository = reservationRepository;
        _paiementService = paiementService;
    }

    [HttpGet]
    public async Task<IActionResult> GetChambresDisponibles([FromQuery] DateTime dateDebut, [FromQuery] DateTime dateFin)
    {
        var chambres = await _chambreRepository.GetChambresDisponibles(dateDebut, dateFin);
        return Ok(chambres);
    }

    [HttpPost]
    public async Task<IActionResult> ReserverChambre([FromBody] Reservation reservation)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var chambre = await _chambreRepository.GetByIdAsync(reservation.ChambreId);
        if (chambre == null)
            return NotFound();

        if (!chambre.EstDisponible(reservation.DateDebut, reservation.DateFin))
            return BadRequest("La chambre n'est pas disponible pour cette période");

        var client = await _clientRepository.GetByIdAsync(reservation.ClientId);
        if (client == null)
            return NotFound();

        var paiementResult = await _paiementService.SimulerPaiement(reservation.Montant);
        if (!paiementResult.Success)
            return BadRequest("Le paiement a échoué");

        reservation.PaiementId = paiementResult.PaiementId;
        await _reservationRepository.AddAsync(reservation);

        return CreatedAtAction(nameof(GetReservationById), new { id = reservation.Id }, reservation);
    }

    [HttpPost]
    public async Task<IActionResult> AnnulerReservation(int reservationId)
    {
        var reservation = await _reservationRepository.GetByIdAsync(reservationId);
        if (reservation == null)
            return NotFound();

        var client = await _clientRepository.GetByIdAsync(reservation.ClientId);
        if (client == null)
            return NotFound();

        var isRemboursable = reservation.EstAnnulableAvecRemboursement();

        if (!isRemboursable)
            return BadRequest("La réservation n'est pas remboursable");

        await _reservationRepository.AnnulerAsync(reservation);

        if (isRemboursable)
        {
            var remboursementResult = await _paiementService.RembourserPaiement(reservation.PaiementId, reservation.Montant);
            if (!remboursementResult.Success)
                return BadRequest("Le remboursement a échoué");
        }

        return Ok();
    }
}