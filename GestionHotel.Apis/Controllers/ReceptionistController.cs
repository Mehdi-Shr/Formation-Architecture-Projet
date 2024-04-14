[Route("api/[controller]")]
[ApiController]
public class ReceptionistsController : ControllerBase
{
    private readonly IChambreRepository _chambreRepository;
    private readonly IReservationRepository _reservationRepository;

    public ReceptionistsController(IChambreRepository chambreRepository, IReservationRepository reservationRepository)
    {
        _chambreRepository = chambreRepository;
        _reservationRepository = reservationRepository;
    }

    [HttpGet("chambres-disponibles")]
    public async Task<ActionResult<IEnumerable<ChambreModel>>> GetChambresDisponibles(DateTime dateDebut, DateTime dateFin)
    {
        // Logique pour obtenir les chambres disponibles pour les dates spécifiées
    }

    [HttpPut("annuler-reservation")]
    public async Task<IActionResult> AnnulerReservation(int idReservation, bool remboursement)
    {
        // Logique pour annuler la réservation d'une chambre
    }

    [HttpPut("gestion-arrivee")]
    public async Task<IActionResult> GestionArrivee(int idReservation)
    {
        // Logique pour gérer l'arrivée du client
    }

    [HttpPut("gestion-depart")]
    public async Task<IActionResult> GestionDepart(int idReservation)
    {
        // Logique pour gérer le départ du client
    }
}
