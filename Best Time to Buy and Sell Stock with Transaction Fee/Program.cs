// See https://aka.ms/new-console-template for more information
Solution s = new Solution();
var prices = new int[] { 1, 3, 2, 8, 4, 9 };
var answer = s.MaxProfit(prices, 2);
Console.WriteLine(answer);
/*
p = [1, 2, 4, 5, 3, 8, 6, 4, 5, 7], fee = 2

min = 1

i = 1 :- 2 is neither less than min (1) nor greater than min + fee (3) ; so skip
i = 2 :- 4 > min+fee(3) ; so profit = (4-2-1) = 1 and min = 4-fee = 2
i = 3 :- 5 > min+fee(2+2 = 4); so profit = profit + (5-fee-min) = (4 - fee - 1) + (5 - fee - (4 - fee)) = 4-fee-1+5-fee-4+fee = (5 - 1 - fee) = 2
Thus for p[3] = 5, the problem is effectively treated as bought at 1 and sold at 5
min = 5-fee = 3

i = 4 :- 3 is neither less than min (3) nor greater than min+fee (5) ; so skip
i = 5 :- 8 > min+fee(3); so profit = profit + (8-fee-min) = 2 + (8-2-3) = 5 and min = 8-fee = 6.
Thus for p[5] = 8, the problem is effectively treated as bought at 1 and sold at 8

i = 6 :- 4 < min (6); so min = 4 (That means we are allowed to start a fresh transaction from 4)

Transaction 2 effectively starts from here

i = 7 :- 5 is neither less than min (4) nor greater than min + fee (6) ; so skip
i = 8 :- 6 is neither less than min (4) nor greater than min + fee (6) ; so skip
i = 9 :- 7 > min + fee (6); so profit = proffit + (7-fee-min) = 5 + (7 -2 - 4) = 5 +1 = 6

Hence final profit = 6



For all those who don't understand why '''minimum = prices[i] - fee''' just like me at first.
Here's the explanation with an example:
prices = [1, 3, 4, 5, 4, 8], fee = 2
Do you take profit of day0 to day3 (prices[3] - prices[0] = 4) and day4 to day5(prices[5] - prices[4] = 4) ?
Or do you take profit of day0 to day5(prices[5] - prices[0] = 7)?
Because transaction fee = 2 , (7-2) > (4-2 + 4-2), 2nd option is better.
So we need to avoid greedily setting 'minimum = day4' , because sell at $5 and buy again at $4 only give us $1 more profit yet costs $2 more transaction fee.
Open a new transaction only if prices[today] < prices[yesterday] - fee. That's why we set 'minimum = prices[i] - fee'
*/




public class Solution
{
  public int MaxProfit(int[] prices, int fee)
  {
    if (prices.Length < 2) return 0;
    int min = prices[0];
    int maxProfit = 0;
    for (int i = 1; i < prices.Length; i++)
    {
      if (prices[i] < min)
      {
        min = prices[i];
      }
      else if (prices[i] > min + fee)
      {
        maxProfit += prices[i] - min - fee;
        min = prices[i] - fee;
      }
    }

    return maxProfit;
  }
}