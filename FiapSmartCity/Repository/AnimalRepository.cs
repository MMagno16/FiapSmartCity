using FiapSmartCity.Models;
using FiapSmartCity.Repository.Context;



namespace FiapSmartCity.Repository
{
    public class AnimalRepository
    {
        public readonly DataBaseContext context;

        public AnimalRepository()
        {
            context = new DataBaseContext();
        }

        public IList<Animal> Listar()
        {
            return context.Animal.ToList();
        }

        public void Inserir(Animal animal)
        {
            
            context.Animal.Add(animal);
            context.SaveChanges();
        }

    }
}