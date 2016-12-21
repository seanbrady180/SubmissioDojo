namespace SubmissionDojo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SubmissionDojo.Models;
    using System.Collections.Generic;



    internal sealed class ConfigurationDojo : DbMigrationsConfiguration<SubmissionDojo.DAL.DojoContext>
    {
        public ConfigurationDojo()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SubmissionDojo.DAL.DojoContext";
        }

        protected override void Seed(SubmissionDojo.DAL.DojoContext context)
        {
            var jiujitsu = new List<JiuJitsu>
            {
                  new JiuJitsu {Name="Arm Bar",Link="https://www.youtube.com/watch?v=Dq8nahFOnI4",Difficulty="Easy",Type="Submission" },
                  new JiuJitsu {Name="Guillotine Choke",Link="https://www.youtube.com/watch?v=2ortF7sjrrc",Difficulty="Intermediate",Type="Submission" },
                  new JiuJitsu {Name="Pulling Guard",Link="https://www.youtube.com/watch?v=f_mroXtVEbg",Difficulty="Easy",Type="TakeDown" },
                  new JiuJitsu {Name=" Guard Sweep",Link="https://www.youtube.com/watch?v=sI7TJMYirIM",Difficulty="Intermediate",Type="Sweep" },
                  new JiuJitsu {Name="Americana ",Link="https://www.youtube.com/watch?v=bFP1Dnzdwl4",Difficulty="Easy",Type="Submission" },
                  new JiuJitsu {Name="Leg Lock ",Link="https://www.youtube.com/watch?v=mqakk--MHoY",Difficulty="Hard",Type="Submission" }
            };

            jiujitsu.ForEach(s => context.JiuJitsu.Add(s));
            context.SaveChanges();

            var wrestling = new List<Wrestling>
            {
                    new Wrestling {Name="Guillotine",Link="https://www.youtube.com/watch?v=tUAeAkECCnY",Difficulty="Hard",Type="Submission" },
                    new Wrestling {Name="DoubleLeg",Link="https://www.youtube.com/watch?v=vFvl1tdr8l4",Difficulty="Eeasy",Type="TakeDown" },
                    new Wrestling {Name="Transitions",Link="https://www.youtube.com/watch?v=ul7LAWJSadw",Difficulty="Hard",Type="Drill" },
                    new Wrestling {Name="Single Leg Takedowns",Link="https://www.youtube.com/watch?v=0WSn-eiQ2qc",Difficulty="Easy",Type="TakeDown" },
                    new Wrestling {Name="Suplex",Link="https://www.youtube.com/watch?v=NojPtq5V7FI",Difficulty="Hard",Type="Throw" },
                    new Wrestling {Name="Go-Behind",Link="https://www.youtube.com/watch?v=qiKNZYxDrBo",Difficulty="Easy",Type="Drill" }
            };

            wrestling.ForEach(s => context.Wrestling.Add(s));
            context.SaveChanges();



            var judo = new List<Judo>
            {
                    new Judo {Name="Daki-wakare",Link="https://www.youtube.com/watch?v=7wT8U4G7q30",Difficulty="Hard",Type="Throw" },
                    new Judo {Name="Foot Sweep",Link="https://www.youtube.com/watch?v=xiirRv1msVc",Difficulty="Intermediate",Type="Throw" },
                    new Judo {Name="Hip Throw",Link="https://www.youtube.com/watch?v=F6wIvVZOP_E",Difficulty="Easy",Type="Throw" },
                    new Judo {Name="Knee Wheel",Link="https://www.youtube.com/watch?v=TDrSEH0tt-w",Difficulty="Easy",Type="Throw" },
                    new Judo {Name="Shoulder Throw",Link="https://www.youtube.com/watch?v=rBhzNk6u0Z4",Difficulty="Hard",Type="Throw" },
                    new Judo {Name="Grip Break",Link="https://www.youtube.com/watch?v=5gHPqokg2zo",Difficulty="Easy",Type="Drill" }
            };

            judo.ForEach(s => context.Judo.Add(s));
            context.SaveChanges();

            var nogi = new List<NoGI>
            {
                    new NoGI {Name="Toe-Hold",Link="https://www.youtube.com/watch?v=mFno2NYeaJI",Difficulty="Intermediate",Type="Submission" },
                    new NoGI {Name="Flying Armbar",Link="https://www.youtube.com/watch?v=JBK-8phKYPQ",Difficulty="Hard",Type="Submission" },
                    new NoGI {Name="Electric Chair",Link="https://www.youtube.com/watch?v=l7nTPVFdlF4",Difficulty="Hard",Type="Submission" },
                    new NoGI {Name="Bow and Arrow choke",Link="https://www.youtube.com/watch?v=bBk02m4QF5c",Difficulty="Intermediate",Type="Submission" },
                    new NoGI {Name="Transitions",Link="https://www.youtube.com/watch?v=bk2E3FDBN7U",Difficulty="Hard",Type="Throw" },
                    new NoGI {Name="Ebi Montage",Link="https://www.youtube.com/watch?v=3QJSsXGjpi0",Difficulty="Easy",Type="Drill" }
            };

            nogi.ForEach(s => context.NoGi.Add(s));
            context.SaveChanges();
        }
    }
}
