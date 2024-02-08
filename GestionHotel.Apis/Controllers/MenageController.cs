public class MenageController : BaseController
{
    private readonly IChambreRepository _chambreRepository;

    public MenageController(IChambreRepository chambreRepository)
    {
        _chambreRepository = chambreRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetChambresANettoyer()
    {
        var chambres = await _chambreRepository.GetChambresANettoyer();
        return Ok(chambres);
    }

    [HttpPost]
    public async Task<IActionResult> MarquerChambreCommeNettoyee(int chambreId)
    {
        var chambre = await _chambreRepository.GetByIdAsync(chambreId);
        if (chambre == null)
            return NotFound();

        await _chambreRepository.MarquerChambreCommeNettoyee(chambre);

        return Ok();
    }

    // ... autres actions (optionnelles)
}