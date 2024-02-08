public interface IPaiementService
{
    Task<PaiementResult> SimulerPaiementAsync(int montant);
    Task<RemboursementResult> RembourserPaiementAsync(string paiementId, int montant);
}