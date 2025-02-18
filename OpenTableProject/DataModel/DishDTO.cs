namespace OpenTableProject.DataModel;

public class DishDTO
{
    /// <summary>
    /// 餐點Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// 餐廳Id
    /// </summary>
    public Guid RestaurantId { get; set; }
    
    /// <summary>
    /// 圖片
    /// </summary>
    public string ImgUrl { get; set; }
    
    /// <summary>
    /// 名稱
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 價格
    /// </summary>
    public decimal Price { get; set; }
}