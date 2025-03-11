using System.Collections.Concurrent;
using OpenableProject.Models;

namespace OpenableProject.Storage;

public static class VendorStorage
{
    private static int _vendorId;

    private static readonly ConcurrentDictionary<int, Vendor> CurrentVendors = new();

    static VendorStorage()
    {
        // 在构造函数中初始化字典
        CurrentVendors.TryAdd(1, new Vendor() { Account = "vendor1", Password = "1qaz@WSX", VendorName = "vendor1-Name" });
        CurrentVendors.TryAdd(2, new Vendor() { Account = "vendor2", Password = "1qaz@WSX", VendorName = "vendor2-Name" });
    }
    public static Vendor Add(Vendor vendor)
    {
        vendor.Id = Interlocked.Increment(ref _vendorId);
        CurrentVendors.TryAdd(vendor.Id, vendor);
        return vendor;
    }
    
    public static Vendor AddByOperator(Vendor vendor)
    {
        vendor.Id = _vendorId++;
        CurrentVendors.TryAdd(vendor.Id, vendor);
        return vendor;
    }
    
    public static List<Vendor> GetAll()
    {
        return CurrentVendors.Values.ToList();
    }
    public static Vendor Get(string account)
    {
        return CurrentVendors.Values.First(x=>x.Account == account);
    }

    public static bool Delete(int vendorId)
    {
        return CurrentVendors.TryRemove(vendorId, out _);
    }
}