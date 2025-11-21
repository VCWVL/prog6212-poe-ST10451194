namespace PROG_POE.Services
{
    public interface IEncryptionService
    {
        byte[] Encrypt(byte[] data, string password);
        byte[] Decrypt(byte[] data, string password);
    }
}
