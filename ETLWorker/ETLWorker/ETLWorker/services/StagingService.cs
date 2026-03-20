public class StagingService
{
    public void Guardar(List<string> datos)
    {
        File.WriteAllLines("staging.txt", datos);
    }
}