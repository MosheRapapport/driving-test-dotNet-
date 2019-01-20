using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace DAL
{
    public class DAL_XML:Idal
    {
        public DAL_XML()
        {
            if (!File.Exists(traineePath))
                CreateFiles();
            else
                LoadData();

        }

        protected static DAL_XML dal;
        public static DAL_XML Dal
        {
            get
            {
                if (dal == null)
                    dal = new DAL_XML();
                return dal;
            }
        }


        XElement traineeRoot;
        string traineePath = @"traineeXml.xml";

        XElement testerRoot;
        string testerPath = @"testerXml.xml";

        XElement testRoot;
        string testPath = @"testXml.xml";


        private void CreateFiles()
        {
            traineeRoot = new XElement("trainees");
            traineeRoot.Save(traineePath);

            testerRoot = new XElement("testers");
            testerRoot.Save(testerPath);

            testRoot = new XElement("tests");
            testRoot.Save(testPath);

        }
        private void LoadData()
        {
            try
            {
                traineeRoot = XElement.Load(traineePath);
                testerRoot = XElement.Load(testerPath);
                testRoot = XElement.Load(testPath);

                traineeRoot.RemoveAll();
                testerRoot.RemoveAll();
                testRoot.RemoveAll();
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }



        //A.R.U.D tester
        BE.Schedule converterSchedule(XElement xElement)
        {
            Schedule schedule = new Schedule();
            Day day = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    schedule.data[i][j] = bool.Parse(xElement.Element("Luz").Element(day.ToString()).Element("hour" + j.ToString()).Value);
                }
                day++;
            }
            return schedule;
        }
        XElement converterSchedule(BE.Schedule schedule)
        {
            Day day = 0;
            XElement xElement = new XElement("Luz");
            for (int i = 0; i < 5; i++)
            {
                XElement xElementDay = new XElement(day.ToString());
                for (int j = 0; j < 6; j++)
                {
                    xElementDay.Add(new XElement("hour"+j.ToString(), schedule.data[i][j].ToString()));
                }
                xElement.Add(xElementDay);
                day++;
            }

            return xElement;
        }

        BE.Tester convertTester(XElement xElement)
        {
            Tester tester = new Tester() { Name = new Name(), Address = new Address(), Expertise = new CarType(), Luz = new Schedule() };
            tester.ID = xElement.Element("ID").Value;
            tester.Name.FirstName = xElement.Element("Name").Element("FirstName").Value;
            tester.Name.LastName = xElement.Element("Name").Element("LastName").Value;
            tester.DayOfBirth = DateTime.Parse(xElement.Element("DayOfBirth").Value);
            tester.Gender = (Gender)Enum.Parse(typeof(Gender),xElement.Element("Gender").Value);
            tester.Address.City = xElement.Element("Address").Element("City").Value;
            tester.Address.StreetName = xElement.Element("Address").Element("StreetName").Value;
            tester.Address.Number = int.Parse(xElement.Element("Address").Element("Number").Value);
            tester.PhoneNumber = xElement.Element("PhoneNumber").Value;
            tester.Experience = int.Parse(xElement.Element("Experience").Value);
            tester.MaxTestWeekly = int.Parse(xElement.Element("MaxTestWeekly").Value);
            tester.MaxDistance = int.Parse(xElement.Element("MaxDistance").Value);
            tester.Expertise.carType = (carType)Enum.Parse(typeof(carType), xElement.Element("Expertise").Element("carType").Value);
            tester.Expertise.gearType = (GearType)Enum.Parse(typeof(GearType), xElement.Element("Expertise").Element("gearType").Value);
            tester.Luz = converterSchedule(xElement);
            return tester;
        }
        XElement convertTester(BE.Tester tester)
        {
            return new XElement("tester",new XElement("ID", tester.ID),
                                                           new XElement("Name", new XElement("FirstName", tester.Name.FirstName)
                                                                              , new XElement("LastName", tester.Name.LastName)),
                                                           new XElement("DayOfBirth",tester.DayOfBirth.ToString()),
                                                           new XElement("Gender",tester.Gender.ToString()),
                                                           new XElement("Address",new XElement("City",tester.Address.City),
                                                                                  new XElement("StreetName",tester.Address.StreetName),
                                                                                  new XElement("Number",tester.Address.Number.ToString())),
                                                           new XElement("PhoneNumber",tester.PhoneNumber),
                                                           new XElement("Experience", tester.Experience),
                                                           new XElement("MaxTestWeekly", tester.MaxTestWeekly),
                                                           new XElement("MaxDistance", tester.MaxDistance),
                                                           new XElement("Expertise", new XElement("carType",tester.Expertise.carType.ToString()),
                                                                                     new XElement("gearType", tester.Expertise.gearType.ToString())),
                                                           new XElement(converterSchedule(tester.Luz))
                                                           );

        }

        public Tester getTester(string id)
        {
            XElement newTester = null;
            try
            {
                newTester = (from item in testerRoot.Elements()
                             where id == item.Element("ID").Value
                             select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
            if (newTester == null)
                return null;
            return convertTester(newTester);
        }

        public List<Tester> GetTesters()
        {
            List<Tester> testers = new List<Tester>();
            testers= (from item in testerRoot.Elements()
                    select convertTester(item)).ToList();
            if(!testers.Any())
                throw new Exception("There is no testers in the database");
            return testers;
        }

        public bool AddTester(Tester tester)
        {
            Tester temp = getTester(tester.ID);
            if (temp!=null)
            {
                throw new Exception("Tester already exist");
            }
            testerRoot.Add(convertTester(tester));
            testerRoot.Save(testerPath);
            return true;
        }

        public bool RemoveTester(Tester tester)
        {
            XElement temp_tester = null;
            temp_tester= (from item in testerRoot.Elements()
                          where tester.ID == item.Element("ID").Value
                          select item).FirstOrDefault();
            if(temp_tester==null)
                throw new Exception("The current tester is not in the database");
            temp_tester.Remove();
            testerRoot.Save(testerPath);

            return true;
        }

        public bool UpdateTester(Tester tester)
        {
            RemoveTester(tester);
            AddTester(tester);
            return true;
        }


        //A.R.U.D trainee

        public List<Trainee> GetTrainees()
        {
            throw new NotImplementedException();
        }

        public bool AddTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public List<Test> GetTests()
        {
            throw new NotImplementedException();
        }

        public bool AddTest(Test drivingTest)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTest(Test drivingTest)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTest(Test drivingTest)
        {
            throw new NotImplementedException();
        }
    }
}
