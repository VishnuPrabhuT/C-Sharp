namespace WebTesting
{
    public interface ITest
    {
        void A_SignUp();
        void B_PriceBookSetup();
        void C_PriceBookCheck();
        void CleanUp();
        void Setup();
    }
}