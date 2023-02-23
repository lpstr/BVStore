using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVStore.Domain.Enums
{
    public enum MembershipType
    {
        None,
        BookClub,
        VideoClub,
        Premium
    }

    public enum ProductType
    {
        Physical,
        Online,
        BookMembership,
        VideoMembership,
        PremiumMembership
    }

    public static class MembershipTypeExtension
    {
        public static MembershipType ToMembership(this ProductType value)
        {
            // insert switch statement here
            switch (value)
            {
                case ProductType.BookMembership: return MembershipType.BookClub;
                case ProductType.VideoMembership: return MembershipType.VideoClub;
                case ProductType.PremiumMembership: return MembershipType.Premium;
                default: return MembershipType.None;
            }
        }
    }

    public static class ProductTypeExtension
    {
        public static ProductType ToProductType(this MembershipType value)
        {
            switch (value)
            {
                case MembershipType.BookClub: return ProductType.BookMembership;
                case MembershipType.VideoClub: return ProductType.VideoMembership;
                case MembershipType.Premium: return ProductType.PremiumMembership;
                default: return ProductType.BookMembership;
            }
        }
    }
}
