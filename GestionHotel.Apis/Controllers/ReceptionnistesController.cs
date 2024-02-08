public class ReceptionnistesController : ClientsController
{
    public ReceptionnistesController(IClientRepository clientRepository, IReservationRepository reservationRepository, IPaiementService paiementService) : base(clientRepository, reservationRepository, paiementService)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetChambresDisponiblesAvecEtat([FromQuery] DateTime dateDebut, [FromQuery] DateTime dateFin)
    {
        var chambres = await _chambreRepository.GetChambresDisponiblesAvecEtat(dateDebut, dateFin);
        return Ok(chambres);
    }

    [HttpPost]
    public async Task<IActionResult> AnnulerReservationReceptionniste(int reservationId)
    {
        var reservation = await _reservationRepository.GetByIdAsync(reservationId);
        if (reservation == null)
            return NotFound();

        var client = await _clientRepository.GetByIdAsync(reservation.ClientId);
        if (client == null)
            return NotFound();

        var isRemboursable = reservation.EstAnnulableAvecRemboursement();

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