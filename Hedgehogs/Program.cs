static int ChangeColor(int[] population, int desiredColor)
{
    var numEncounters = 0;
    while (true)
    {
        var allDesiredColor = population.All(count => count <= 0 || count == population[desiredColor]);

        if (allDesiredColor)
        {
            return numEncounters;
        }

        int largestColor1 = -1, largestCount1 = -1;
        int largestColor2 = -1, largestCount2 = -1;

        for (var i = 0; i < population.Length; i++)
        {
            if (i == desiredColor)
            {
                continue;
            }

            var count = population[i];
            if (count > largestCount1)
            {
                largestCount2 = largestCount1;
                largestColor2 = largestColor1;
                largestCount1 = count;
                largestColor1 = i;
            }
            else if (count > largestCount2)
            {
                largestCount2 = count;
                largestColor2 = i;
            }
        }

        if (largestColor1 >= 0 && largestColor2 >= 0)
        {
            if (population[largestColor1] >= 1 && population[largestColor2] >= 1)
            {
                population[largestColor1] -= 1;
                population[largestColor2] -= 1;
                population[3 - largestColor1 - largestColor2] += 2;
                numEncounters += 1;
            }
            else
            {
                var nonDesiredColorsCount = population.Count(count => count > 0 && count != population[desiredColor]);

                if (nonDesiredColorsCount == 1)
                {
                    return -1;
                }
            }
        }
        else
        {
            return -1;
        }
    }
}

var population = new int[] { 9, 1, 9 };
var desiredColor = 1;
var numEncounters = ChangeColor(population, desiredColor);
Console.WriteLine(numEncounters >= 0
    ? $"The minimum number of encounters to change all hedgehogs to a given color: {numEncounters}"
    : "It is not possible to change the color of all hedgehogs to a given color.");