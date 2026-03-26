class Order
{
    private List<Product> _order;
    private Customer _customer;
    public Order(Customer customer)
    {
        _order = new List<Product>();
        _customer = customer;
    }
    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _order)
        {
            double productAmt = product.CalculateTotal();
            total += productAmt;
        }

        return total;
    }
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _order)
        {
            label += $"- {product.GetProductInfo()}\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }

    public void AddToOrder(Product product)
    {
        _order.Add(product);
    }
}