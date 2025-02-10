using IAlbumDB.Domain.Interfaces.Mapper;

/// This mapping class is not used in the context of this project but for now kept in the code base for possible future use or better placement
namespace IAlbumDB.Infrastructure.Mappers
{
    public class AutoMapping<TOut, TIn> : IMapping<TOut, TIn>
    where TOut : class
    where TIn : class
    {
        public TOut Map(TIn input)
        {
            TOut output = (TOut)Activator.CreateInstance(typeof(TOut)) ?? throw new Exception($"Unable to create output type of type {typeof(TOut)}");

            foreach (var outProp in typeof(TOut).GetProperties())
            {
                foreach (var inProp in typeof(TIn).GetProperties())
                {
                    if (outProp.Name == inProp.Name && outProp.PropertyType == inProp.PropertyType)
                    {
                        Console.WriteLine($"Found a match: {outProp.Name} and {inProp.Name}");
                        var value = inProp.GetValue(input);
                        outProp.SetValue(output, value);

                    }
                }
            }

            return output;
        }
    }
}
