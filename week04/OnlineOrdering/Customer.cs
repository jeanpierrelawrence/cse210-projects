class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }
    public string GetCustomerInfo()
    {
        return $"It is {_address.IsInUS()} that {_name} lives in the US.";
    }

    public string GetShippingLabel()
    {
        return $"{_name}\n{_address.Display()}";
    }

    public bool IsInUS()
    {
        return _address.IsInUS();
    }
}