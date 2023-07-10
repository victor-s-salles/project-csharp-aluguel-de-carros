using RentCars.Types;

namespace RentCars.Models;

public class Rent
{
    public Vehicle Vehicle { get; set; }
    public Person Person { get; set; }
    public int DaysRented { get; set; }
    public double Price { get; set; }
    public RentStatus Status { get; set; }

    //10 - Crie o construtor de `Rent` seguindo as regras de negócio
    public Rent(Vehicle vehicle, Person person, int daysRented)
    {
        Status = RentStatus.Confirmed;
        Vehicle = vehicle;
        Person = person;

        if (person is PhysicalPerson)
        {
            Price = vehicle.PricePerDay * daysRented;
        }
        else if (person is LegalPerson)
        {
            Price = vehicle.PricePerDay * daysRented * 0.9;
        }
        person.Debit = Price;
        vehicle.IsRented = true;

    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Cancel()
    {
        Status = RentStatus.Canceled;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Finish()
    {
        Status = RentStatus.Finished;
    }
}