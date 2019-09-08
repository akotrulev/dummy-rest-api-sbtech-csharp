using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace dummyapi.Poco
{
    public class PostEmployeePoco
    {

        public String id { get; set; }
        public String name { get; set; }
        public String salary { get; set; }
        public String age { get; set; }

        public void SetDefaultValues()
        {
            this.name = "Default name";
            this.age = "15";
            this.salary = "0";
        }
        public override bool Equals(object obj)
        {
            return obj is PostEmployeePoco poco &&
                   id == poco.id &&
                   name == poco.name &&
                   salary == poco.salary &&
                   age == poco.age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, name, salary, age);
        }

        public override string ToString()
        {
            return "PostEmployeePoco{" +
                "name='" + name + '\'' +
                ", salary='" + salary + '\'' +
                ", age='" + age + '\'' +
                '}';
        }
    }
}
