namespace WebAPIProject.Models
{
    public class Character
    {
        public Character(int? id, string name, int strength, int speed, int age, int level, int equipmentId)
        {
            Id = id;
            Name = name;
            Strength = strength;
            Speed = speed;
            Age = age;
            Level = level;
            EquipmentId = equipmentId;
        }

        public Character()
        {
            return;
        }



        public int? Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Age { get; set; }

        public int Level { get; set; }
        public int EquipmentId { get; set; }
    }
}
