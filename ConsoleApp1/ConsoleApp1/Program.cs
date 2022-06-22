using System;
using ConsoleApp1.Helpers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Pharmacy pharmacy = new Pharmacy("Zeferan",200,10000,"Sabuncu.Zabrat");
            Employee admin = new Employee();
            admin.Username = "admin";
            admin.Password = "admin123";
            admin.RoleType = RoleType.ADMIN;
            pharmacy.employees.Add(admin);
            login:
            Helper.Print("Login",ConsoleColor.Green);
            while (true)
            {
                
                Helper.Print("Username daxil edin",ConsoleColor.Green);
                string username = Console.ReadLine();
                Helper.Print("Password daxil edin", ConsoleColor.Green);
                string password = Console.ReadLine();   //SEHV DAXIL ETDIKDE ERROR QALIB!!!!!

                foreach (var item in pharmacy.employees)
                {
                    if (item.Username==username&&item.Password==password)
                    {
                        if (item.RoleType== RoleType.ADMIN)
                        {
                            Helper.Print("Siz admin rolundasiniz", ConsoleColor.Yellow);
                            admin:
                            Helper.Print("1.Admin Panel",ConsoleColor.Green);
                            Helper.Print("2.Satis et",ConsoleColor.Green);
                            Helper.Print("3.Melumatlari yenile",ConsoleColor.Green);
                            string nmenu = Console.ReadLine();
                            bool IsInt = int.TryParse(nmenu, out int menu);
                            if (!IsInt)
                            {
                                Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                goto admin;
                            }
                            switch (menu)
                            {
                                case 1:
                                  
                                    Helper.Print("1.Emplooye elave et", ConsoleColor.Green);
                                    Helper.Print("2.Drug elave et", ConsoleColor.Green);
                                    Helper.Print("3.Drug sil", ConsoleColor.Green);
                                    Helper.Print("4.Derman editle", ConsoleColor.Green);
                                    Helper.Print("5.Emplooye sil", ConsoleColor.Green);
                                    Helper.Print("6.Emplooye editle", ConsoleColor.Green);
                                    string adminmen = Console.ReadLine();
                                    bool IsInt1 = int.TryParse(adminmen, out int adminmenu);
                                    if (!IsInt1)
                                    {
                                        Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                        goto case 1;
                                    }
                                    switch (adminmenu)
                                    {
                                        case 1:
                                            #region addemploye
                                            Helper.Print("Emplooye name daxil edin", ConsoleColor.Yellow);
                                            string ename = Console.ReadLine();
                                            Helper.Print("Emplooye surname daxil edin", ConsoleColor.Yellow);
                                            string sname = Console.ReadLine();
                                            dateTime:
                                            Helper.Print("Emplooye dogum tarixini qeyd edin: mm/dd/yyyy ", ConsoleColor.Yellow);
                                            string edate = Console.ReadLine();
                                            bool isDate = DateTime.TryParse(edate, out DateTime dateTime);
                                            if (!isDate)
                                            {
                                                Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                                goto dateTime;
                                            }
                                            esalary:
                                            Helper.Print("Emplooye salary qeyd edin ", ConsoleColor.Yellow);
                                            string esal = Console.ReadLine();
                                            bool IsSal = int.TryParse(esal, out int esalary);
                                            if (!IsSal)
                                            {
                                                Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                                                goto esalary;
                                            }
                                            if (esalary>pharmacy.MinSalary)
                                            {
                                                Helper.Print("Aptek bu maasi qarshilaya bilmir, zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                                goto esalary;
                                            }
                                            eusername:
                                            Helper.Print("Emplooye username daxil edin", ConsoleColor.Yellow);
                                            string eusername = Console.ReadLine();
                                            foreach (var item1 in pharmacy.employees)
                                            {
                                                if (item1.Username==eusername)
                                                {
                                                    Helper.Print("Bu username artiq movcuddur,Zehmet olmasa bashqa username istifade edin", ConsoleColor.Red);
                                                    goto eusername;
                                                }
                                            }
                                            Helper.Print("Emplooye password daxil edin", ConsoleColor.Yellow);
                                            string epassword = Console.ReadLine();                              //PASSWORD YOXLANISI QALIBB!!!!
                                            Helper.Print("Emplooye roletype qeyd edin: Admin/Staff? ", ConsoleColor.Yellow);
                                            string erole = Console.ReadLine();
                                            Employee employee1 = new Employee();
                                            employee1.Name = ename;
                                            employee1.Surname = sname;
                                            employee1.BirthDate = dateTime;
                                            employee1.Salary = esalary;
                                            employee1.Username = eusername;
                                            employee1.Password = epassword;
                                            if (erole.ToUpper() == "admin".ToUpper())
                                            {
                                                employee1.RoleType = RoleType.ADMIN;
                                            }
                                            else if (erole.ToUpper()== "staff".ToUpper())
                                            {
                                                employee1.RoleType = RoleType.STAFF;
                                            }
                                            
                                            Helper.Print($"{ename} adli emplooye yaradildi", ConsoleColor.Yellow);
                                            pharmacy.employees.Add(employee1);
                                            goto login;
                                            break;
                                        #endregion
                                        case 2:
                                            #region adddrug
                                            Drug drug = new Drug();
                                        name1:
                                            Helper.Print("Derman adini daxil edin", ConsoleColor.Yellow);
                                            string dname = Console.ReadLine();
                                            Helper.Print("Dermanin tipini qeyd edin: SYROB/POWDER/TABLET ?", ConsoleColor.Yellow);
                                            string dtype = Console.ReadLine();
                                            if (dtype.ToUpper()=="syrob".ToUpper())
                                            {
                                                drug.DrugType = DrugType.SYROB;
                                            }
                                            else if (dtype.ToUpper() == "powder".ToUpper())
                                            {
                                                drug.DrugType = DrugType.POWDER;
                                            }
                                            else if (dtype.ToUpper() == "tablet".ToUpper())
                                            {
                                                drug.DrugType = DrugType.TABLET;
                                            }
                                            foreach (var item2 in pharmacy.drugs)
                                            {
                                                if (item2.Name==dname&&item2.DrugType==drug.DrugType) 
                                                {
                                                    Helper.Print("Bu adli ve typl derman artiq movcuddur",ConsoleColor.Red);

                                                    goto name1;
                                                }
                                            }
                                            IsCount:
                                            Helper.Print("Dermanin sayini qeyd edin", ConsoleColor.Yellow);
                                            string dcoun = Console.ReadLine();
                                            bool IsCount = int.TryParse(dcoun, out int dcount);
                                            if (!IsCount)
                                            {
                                                Helper.Print("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                                goto IsCount;
                                            }
                                            purchase:
                                            Helper.Print("Dermanin alis qiymetini daxil edin", ConsoleColor.Yellow);
                                            string dpurch = Console.ReadLine();
                                            bool isPur = double.TryParse(dpurch, out double dpurprice);
                                            if (!isPur)
                                            {
                                                Helper.Print("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                                goto purchase;
                                            }
                                            saleprice:
                                            Helper.Print("Dermanin satis qiymetini daxil edin", ConsoleColor.Yellow);
                                            string dsal = Console.ReadLine();
                                            bool isSal = double.TryParse(dpurch, out double saleprice);
                                            if (!isSal)
                                            {
                                                Helper.Print("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                                                goto saleprice;
                                            }
                                            if (pharmacy.Budget<(dpurprice*dcount))
                                            {
                                                Helper.Print("Budceni kecdiyi ucun derman elave oluna bilmedi", ConsoleColor.Red);
                                                goto admin;
                                            }
                                            drug.Name = dname;
                                            drug.Count = dcount;
                                            drug.PurchasePrice = dpurprice;
                                            drug.SalePrice = saleprice;
                                            pharmacy.drugs.Add(drug);
                                            pharmacy.Budget = pharmacy.Budget - (dpurprice*dcount);
                                            Helper.Print($"{dname} adli derman elave olundu", ConsoleColor.Green);
                                            break;
                                        #endregion
                                        case 3:
                                            #region delete drug
                                            if (pharmacy.drugs.Count==0)
                                            {
                                                Helper.Print("Hal hazirda bazada derman yoxdur maci<3", ConsoleColor.Red);
                                                goto login;
                                            }
                                            Helper.Print("Axtardiqiniz dermanin adini daxil edin:", ConsoleColor.Yellow);
                                            string search = Console.ReadLine();
                                            foreach (var item4 in pharmacy.drugs)
                                            {
                                                if (item4.Name.ToLower()==search.ToLower())
                                                {
                                                    Helper.Print($"{item4.Id} {item4.Name} {item4.DrugType}", ConsoleColor.Green);

                                                }
                                            }
                                            did:
                                            Helper.Print("Silmek istediyiniz dermanin  ID qeyd edin", ConsoleColor.Yellow);
                                            string didd = Console.ReadLine();
                                            bool isId = int.TryParse(didd, out int did);
                                            if (!isId)
                                            {
                                                Helper.Print("Yanlis daxil edildi zehmet olmasa yeniden daxil edin:", ConsoleColor.Red);
                                                goto did;
                                            }
                                            foreach (var item5 in pharmacy.drugs)
                                            {
                                                if (item5.Id==did)
                                                {
                                                    pharmacy.drugs.Remove(item5);
                                                    pharmacy.Budget = pharmacy.Budget + (item5.PurchasePrice*item5.Count);
                                                    Helper.Print($"{item5.Name} adli derman silindi twk", ConsoleColor.Blue);
                                                    break;
                                                }
                                            }
                                            break;
                                        #endregion
                                        case 4:
                                            Helper.Print("Editlemek istediyiniz dermanin adini daxil edin:", ConsoleColor.Yellow);
                                            string edit = Console.ReadLine();
                                            foreach (var item4 in pharmacy.drugs)
                                            {
                                                if (item4.Name.ToLower() == edit.ToLower())
                                                {
                                                    Helper.Print($"{item4.Id} {item4.Name} {item4.DrugType}", ConsoleColor.Green);

                                                }
                                            }
                                            didd:
                                            Helper.Print("Editlemek istediyiniz dermanin  ID qeyd edin", ConsoleColor.Yellow);
                                            string ddid = Console.ReadLine();
                                            bool isIdd = int.TryParse(ddid, out int _did);
                                            if (!isIdd)
                                            {
                                                Helper.Print("Yanlis daxil edildi zehmet olmasa yeniden daxil edin:", ConsoleColor.Red);
                                                goto didd;
                                            }
                                            foreach (var item6 in pharmacy.drugs)
                                            {
                                                if (item6.Id==_did)
                                                {
                                                    //yeni melumatlar daxil etmek qalb!
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else if (item.RoleType == RoleType.STAFF)
                        {
                            Helper.Print("1.Satis et", ConsoleColor.Green);
                            Helper.Print("2.Melumatlari yenile", ConsoleColor.Green);
                        }

                    }
                }
            }
            
        }
    }
}
