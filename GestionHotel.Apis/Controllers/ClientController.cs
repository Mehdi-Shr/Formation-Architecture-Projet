[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientRepository _clientRepository;
    private readonly IChambreRepository _chambreRepository;
    private readonly IReservationRepository _reservationRepository;

    public ClientsController(IClientRepository clientRepository, IChambreRepository chambreRepository, IReservationRepository reservationRepository)
    {
        _clientRepository = clientRepository;
        _chambreRepository = chambreRepository;
        _reservationRepository = reservationRepository;
    }

    [HttpGet("chambres-disponibles")]
    public async Task<ActionResult<IEnumerable<ChambreModel>>> GetChambresDisponibles(DateTime dateDebut, DateTime dateFin)
    {
        // Logique pour obtenir les chambres disponibles pour les dates spécifiées
    }

    [HttpPost("reserver-chambre")]
    public async Task<ActionResult<ReservationModel>> ReserverChambre(int idClient, int idChambre, DateTime dateDebut, DateTime dateFin, string numeroCarte)
    {
        // Logique pour réserver une chambre pour le client spécifié
    }

    [HttpDelete("annuler-reservation")]
    public async Task<IActionResult> AnnulerReservation(int idReservation)
    {
        // Logique pour annuler la réservation du client
    }

}