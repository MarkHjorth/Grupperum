using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupperumServer.ModelLayer;

namespace TestData
{
    public class TestContainer
    {
        public List<ClassRoom> classRooms { get; set; }
        
        public List<Group> groups { get; set; }

        public List<RequestClassroom> requests { get; set; }

        public TestContainer()
        {
            classRooms = new List<ClassRoom>();
            groups = new List<Group>();
            requests = new List<RequestClassroom>();
            CreateRooms();
            CreateGroups();
            CreateRequests();
        }

        private void CreateRooms()
        {
            for(int i = 0; i < 50; i++)
            {
                int[] iray = { 10, 15, 20, 25, 30 };
                Random rand = new Random();

                int indx = rand.Next(0, 4);
                
                ClassRoom c = new ClassRoom(i, iray[indx], wat(rand), wat(rand), wat(rand));
                classRooms.Add(c);
            }
        }
        
        private void CreateGroups()
        {
            for(int i = 0; i < 100; i++)
            {
                int[] iray = { 1, 2, 3, 4, 5, 6, 7 };
                Random rand = new Random();

                int indx = rand.Next(6);
                string name = ("Group " + i);
                List<int> ls = new List<int>();
                
                for(int j = 0; j < indx; j++)
                {
                    ls.Add(j);
                }

                Group g = new Group(i, name, ls);
                groups.Add(g);
            }
        }

        private void CreateRequests()
        {
            int i = 1;
            int[] iray = { 0, 1, 2, 3, 4, 5, 6, 7 };
            Random rand = new Random();
            int reqcode;

            foreach (Group group in groups)
            {
                reqcode= rand.Next(7);
                RequestClassroom request = new RequestClassroom(group.Id, group.Size(), reqcode);
                i++;
            }
        }

        private bool wat(Random rand)
        {
            bool wat = false;
            if (rand.Next(0, 1) == 1)
            {
                wat = true;
            }
            return wat;
        }
    }
}
