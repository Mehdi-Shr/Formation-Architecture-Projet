[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IChambreRepository _chambreRepository;

    public ReservationController(IChambreRepository chambreRepository)
    {
        _chambreRepository = chambreRepository;
    }

    [HttpGet("chambres-a-nettoyer")]
    public async Task<ActionResult<IEnumerable<ChambreModel>>> GetChambresANettoyer()
    {
        // Logique pour obtenir les chambres à nettoyer
    }

    [HttpPut("marquer-nettoyage")]
    public async Task<IActionResult> MarquerNettoyage(int idChambre)
    {
        // Logique pour marquer une chambre comme nettoyée
    }

}
