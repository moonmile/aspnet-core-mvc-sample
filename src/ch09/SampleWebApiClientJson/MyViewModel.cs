using SampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApiClientJson;

internal class MyViewModel  : Prism.Mvvm.BindableBase
{
    private Person _person = new Person();
    private List<Person> _people = new List<Person>();
    private List<Address> _addresses =  new List<Address>();

    public Person Person
    {
        get => _person;
        set => SetProperty(ref _person, value, nameof(Person));
    }
    public List<Person> People
    {
        get => _people;
        set => SetProperty(ref _people, value, nameof(People));
    }
    public List<Address> Addresses
    {
        get => _addresses;
        set => SetProperty(ref _addresses, value, nameof(Addresses));
    }

    public int ID
    {
        get => _person.Id;
        set
        {
            _person.Id = value;
            OnPropertyChanged( 
                new System.ComponentModel.PropertyChangedEventArgs( nameof(Person) ) );  
        }
    }
}
