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

        public TestContainer()
        {
            classRooms = new List<ClassRoom>();
            groups = new List<Group>();
            CreateRooms();
            CreateGroups();
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

                Group g = new Group(name, ls);
                groups.Add(g);
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
