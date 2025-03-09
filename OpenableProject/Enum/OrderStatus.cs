namespace OpenableProject.Enum;

public enum OrderStatus
{
    Unknown = 0,      // 未知狀態，避免未初始化
    Pending = 1,      // 訂單待處理
    InProgress = 2,   // 訂單處理中
    Shipped = 3,      // 訂單已出貨
    Delivered = 4,    // 訂單已送達
    Cancelled = 5,    // 訂單已取消
    Returned = 6      // 訂單已退貨
}