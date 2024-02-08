public class ReservationController : BaseController
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationController(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var reservation = await _reservationRepository.GetByIdAsync(id);
        if (reservation == null)
            return NotFound();

        return Ok(reservation);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reservations = await _reservationRepository.GetAllAsync();
        return Ok(reservations);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Reservation reservation)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _reservationRepository.AddAsync(reservation);

        return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Reservation reservation)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingReservation = await _reservationRepository.GetByIdAsync(reservation.Id);
        if (existingReservation == null)
            return NotFound();

        await _reservationRepository.UpdateAsync(reservation);

        return Ok(reservation);
    }

    public async Task<IActionResult> Delete(int id)
{
    var reservation = await _reservationRepository.GetByIdAsync(id);
    if (reservation == null)
        return NotFound();

    await _reservationRepository.DeleteAsync(id);

    return NoContent();
}

[HttpGet]
public async Task<IActionResult> GetByClientId(int clientId)
{
    var reservations = await _reservationRepository.GetReservationsByClientId(clientId);
    return Ok(reservations);
}

[HttpGet]
public async Task<IActionResult> GetByChambreId(int chambreId)
{
    var reservations = await _reservationRepository.GetReservationsByChambreId(chambreId);
    return Ok(reservations);
}

[HttpPost]
public async Task<IActionResult> AnnulerReservation(int reservationId)
{
    var reservation = await _reservationRepository.GetByIdAsync(reservationId);
    if (reservation == null)
        return NotFound();

    if (!reservation.EstAnnulableAvecRemboursement())
        return BadRequest("La réservation ne peut pas être annulée avec remboursement.");

    await _reservationRepository.AnnulerReservationAsync(reservationId);

    return Ok();
}
