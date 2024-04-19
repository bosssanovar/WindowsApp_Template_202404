using BBBEntity;

namespace DomainService
{
    public class BBBLehgthChecker(AAAEntity.AAAEntity _aaaEntity) : IBBBLehgthChecker
    {
        public bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value)) return true;

            return value.Length <= _aaaEntity.AAA.Value;
        }

        public string Substring(string value)
        {
            return value[.._aaaEntity.AAA.Value];
        }
    }
}
