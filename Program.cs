using System;
using System.Collections.Generic;
using System.Text;


namespace kolokwium_zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            var accounts = new List<Account>();
        
            int choice;

            while (true)
            {
                ShowMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        foreach (var item in accounts)
                        {
                            Console.WriteLine(item.ToString());
          
                        }
                        break;

                    case 2:
                        FindRecordByLastName(accounts);
                        break;

                    case 5:
                        new RecordCreator(accounts).Add();
                        break;
                }
            }

            void ShowMenu()
            {
                var builder = new StringBuilder();

                builder.AppendLine("1.Show all records");
                builder.AppendLine("1.Show by record by name");
                builder.AppendLine("5.Add record");
                Console.WriteLine(builder.ToString());
            }

            void FindRecordByLastName(List<Account> accounts)
            {
                Console.Write("Type last name: ");
                string lastName = Console.ReadLine();
                var account = accounts.Find(w => w.LastName == lastName);

                Console.WriteLine(account.ToString());
            }

        }
  
    }
}

public class RecordCreator
{
    private List<Account> accounts;

    public RecordCreator(List<Account> accounts)
    {
        this.accounts = accounts;
    }

    public void Add()
    {
        string firstName = GetFirstName();
        string lastName = "Marut";
        string numTel = "123456789";
        string address = "sezamkowa";

        Console.WriteLine("1.Individual / 2.Company?");

        int choicePerson = Convert.ToInt32(Console.ReadLine());
        //Convert.ToInt32(IorC);

        if(choicePerson == 1)
        {
            var individual = new Individual(firstName, lastName, numTel, address);
            accounts.Add(individual);
        }
        else
        {
            var company = new Company(firstName, lastName, numTel, address,"Google","12345");
            accounts.Add(company);
        }
    }

    private string GetFirstName()
    {
        Console.WriteLine("Please type a first name: ");
        string firstName = Console.ReadLine();
        return firstName;
    }

}



public abstract class Account
{
    private string firstName;
    private string lastName;
    private string numTel;
    private string address;

    public string LastName
    {
        get
        {
            return lastName;
        }

    }
    public string NumTel
    {
        get
        {
            return numTel;
        }
    }

    protected Account(string firstName, string lastName, string numTel, string address)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.numTel = numTel;
        this.address = address;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"First name: {firstName}");
        builder.AppendLine($"Last name: {lastName}");
        builder.AppendLine($"Phone number: {numTel}");
        builder.AppendLine($"Address: {address}");
        return builder.ToString();
    }

}

public class Individual : Account
{
    public Individual(string firstName, string lastName, string numTel,string address) : base(firstName, lastName, numTel, address)
    {

    }

    public override string ToString()
    {
        var baseData = base.ToString();
        var builder = new StringBuilder();
        builder.AppendLine($"Individual");
        builder.AppendLine(baseData);
        return builder.ToString();
    }
}

public class Company : Account
{
    public string companyName;
    public string nip;

    public Company(string firstName, string lastName,string numTel,string address, string companyName, string nip) : base(firstName, lastName, numTel, address)
    {
        this.companyName = companyName;
        this.nip = nip;
    }

    public override string ToString()
    {
        var baseData = base.ToString();
        var builder = new StringBuilder();
        builder.AppendLine($"Company:");
        builder.AppendLine(baseData);
        builder.AppendLine($"Company name: {companyName}");
        builder.AppendLine($"Company nip: {nip}");
        return builder.ToString();
    }
}
