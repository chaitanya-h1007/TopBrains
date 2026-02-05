namespace ExceptionHandling
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string MembershipType { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Member(int id, string name, string type, int months)
        {
            MemberId = id;
            Name = name;
            MembershipType = type;
            JoinDate = DateTime.Now;
            ExpiryDate = JoinDate.AddMonths(months);
        }
    }

    public class GymManager
    {
        public static List<Member> members = new List<Member>();
        static int counter = 1;

        public void AddMember(string name, string type, int months)
        {
            members.Add(new Member(counter++, name, type, months));
        }
    }

    public class GymApp
    {
        public static void Main(string[] args)
        {
            GymManager gm = new GymManager();
            gm.AddMember("Ravi", "Premium", 6);
            gm.AddMember("Aman", "Basic", 3);

            var grouped = gm.GroupMembersByMembershipType();
            foreach (var g in grouped)
            {
                Console.WriteLine("Type: " + g.Key);
                foreach (var m in g.Value)
                    Console.WriteLine(m.Name);
            }
        }
    }
    
}
