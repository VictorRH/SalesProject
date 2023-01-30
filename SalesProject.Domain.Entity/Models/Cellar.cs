using SalesProject.Domain.Core;
using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class Cellar: ClassBase
{
    //public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<BuyDet> BuyDets { get; } = new List<BuyDet>();

    public virtual ICollection<BuyOrderDet> BuyOrderDets { get; } = new List<BuyOrderDet>();

    public virtual ICollection<BuyReturnDet> BuyReturnDets { get; } = new List<BuyReturnDet>();

    public virtual ICollection<CellarTransfer> CellarTransferCellarDestinations { get; } = new List<CellarTransfer>();

    public virtual ICollection<CellarTransfer> CellarTransferCellarOrigins { get; } = new List<CellarTransfer>();

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    public virtual ICollection<MinMaxProd> MinMaxProds { get; } = new List<MinMaxProd>();

    public virtual ICollection<SaleDet> SaleDets { get; } = new List<SaleDet>();

    public virtual ICollection<SaleOrderDet> SaleOrderDets { get; } = new List<SaleOrderDet>();

    public virtual ICollection<SaleReturnDet> SaleReturnDets { get; } = new List<SaleReturnDet>();

    public virtual ICollection<TransactionDetail> TransactionDetails { get; } = new List<TransactionDetail>();
}
