namespace SpaceShip.Engine
{


    public class Engine
    {

        Weapon blaster = new Weapon("Blaster", 8, 10, 10);
        Weapon laserStaff = new Weapon("Laser Staff", 10, 12, 6);
        Weapon energyShield = new Weapon("Energy Shield", 12, 14, 2);

        Monster wolf = new Monster("Wolf", 4, 2, 2);
        Monster orc = new Monster("Orc", 5, 2, 3);
        Monster zombie = new Monster("Zombie", 6, 1, 3);


    }
}