public class PaiementService : IPaiementService
{
    public async Task<PaiementResult> SimulerPaiement(int montant)
    {
        // TODO: Implémenter l'appel à un service de paiement externe
        return new PaiementResult { Success = true, PaiementId = "123456" };
    }

    public async Task<RemboursementResult> RembourserPaiement(string paiementId, int montant)
    {
        // TODO: Implémenter l'appel à un service de remboursement externe
        return new RemboursementResult { Success = true };
    }
}