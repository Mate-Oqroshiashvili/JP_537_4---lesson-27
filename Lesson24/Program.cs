using Lesson24.Enums;
using Lesson24.Extentions;
using Lesson24.Models;

User user = new User("Mate Oqroshiashvili", "mate@gmail.com", "Mate_123", 1000m);

await JSONFileHelper<User>.WriteInJsonAsync(FILE_TYPES.Users, user);

User? user1 = await JSONFileHelper<User>.ReadFromJsonAsync(FILE_TYPES.Users);

await user.ChangePassowrdAsync("MateOqro_123");

await JSONFileHelper<User>.WriteInJsonAsync(FILE_TYPES.Users, user);

User? user2 = await JSONFileHelper<User>.ReadFromJsonAsync(FILE_TYPES.Users);

Console.WriteLine(user);
Console.WriteLine(user1);
Console.WriteLine(user2);