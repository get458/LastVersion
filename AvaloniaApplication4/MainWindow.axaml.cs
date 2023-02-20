using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks.Dataflow;
using Avalonia.Controls;
using AvaloniaApplication4.Models;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;

namespace AvaloniaApplication4;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        
        ShowProduct();
    }
    
    public void ShowProduct()
    {
        using (AvaloniaContext db = new AvaloniaContext())
        {
            var products1 = db.Products.ToList().Join(db.Cars,
                c => c.CarId,
                u => u.Id,
                (c, u) => new
                {
                    car_id = u.CarName,
                    Color = c.Color,
                    Count = c.Count,
                    Price = c.Price
                });
            ProductGrid.Items = products1;
        }
    }
}