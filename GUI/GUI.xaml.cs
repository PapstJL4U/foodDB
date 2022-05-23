using System;
using System.Windows;
namespace Foood
{
  public partial class GUI : ContentPage
  {
    public GUI()
    {
      InitializeComponent();
      OnClear(this, null);
    }
  }
}