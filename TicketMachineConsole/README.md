Journal
===========

2023-10-24
-----------------------------------------------------

#### 4102 Unit Test ParkingMachine - Part 3
After spending some time with part 1 and 2, I got to part 3 without much issue. This part, however, was a little more complicated 
than the previous ones. I started out by learning about DateTime and TimeSpan which I was supposed to use to calculate how long a 
purchased ticket is to last for. After a little back and forth I eventually ended up with something that passed most tests, but I was
fairly certain I had done something incorrectly/inefficiently. With some help, I got back on track and restructured the code slightly.
It didn't take too long to fix what I had done incorrectly, and a major fix in the code was using properties of the TimeSpan to get
the days, hours, and minutes, as follows: `ticketTimeSpan.Days`. I had tried to get these values from the TimeSpan by converting it
to a string and using Split(), but when some values such as hours were set to 0, the values would disappear and the tests would fail.
Using TimeSpan's properties (as intended) fixed this problem. And after a final quick fix, part 3 was done.