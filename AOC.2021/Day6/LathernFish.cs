namespace AOC._2021.Day6
{
    public class LaternFish
    {
        private int daysToBirth;
        public LaternFish(int leftDays)
        {
            this.daysToBirth = leftDays;
        }

        public LaternFish() => daysToBirth = 8;

        public void GetOlder()
        {
            if (daysToBirth != 0)
                daysToBirth--;
            else
                daysToBirth = 6;
        }

        public bool ShouldGiveBirth() => daysToBirth == 0;
    }
}
