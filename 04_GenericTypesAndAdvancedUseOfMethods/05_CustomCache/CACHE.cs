public class CACHE <Tkey,TData>
{
    Dictionary<Tkey, TData> _cachedData = new Dictionary<Tkey, TData>();
     public TData get(Tkey key ,Func<Tkey, TData> getForTheFirstTime)
        {
             if (!_cachedData.ContainsKey(key))
               {
                   _cachedData[key] = getForTheFirstTime(key);
               }
              return _cachedData[key];
         }

}
