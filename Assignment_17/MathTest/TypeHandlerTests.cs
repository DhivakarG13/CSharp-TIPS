using MockingFramework;

namespace MathTest
{
    public class TypeHandlerTests
    {
        [Fact]
        public void CreateType_ReturnsAType()
        {
            TypeHandler typeHandler = new TypeHandler();
            Type? newType = typeHandler.CreateType();
            Assert.False(newType == null);
        }

        [Fact]
        public void CreateType_ReturnsATypeWithMethodThareturnDefaultValueWhenCalled()
        {
            TypeHandler typeHandler = new TypeHandler();
            Type? newType = typeHandler.CreateType();
            IMaths newObject = (IMaths)Activator.CreateInstance(newType);
            int actualValue = newObject.Add(1, 2);
            Assert.Equal(0, actualValue);
        }
    }
}