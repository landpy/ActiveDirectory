> About 7 years history - start from 2010 (https://landpyactivedirectory.codeplex.com/), which will help you to manage Active Directory easily! 
> This library has been used in **Lenovo**, **Tempursealy**, **Sony**, **BoostSolutions** and other corporations. Enjoy it!
> I have started my biz! [http://fewbox.com](http://fewbox.com)
![FewBox](http://www.fewbox.com/images/chicActiveDirectory.png)
## [For more information plz click here to visit the "Getting Start"](https://github.com/landpy/ActiveDirectory/wiki/Getting-Start)
E.G: Update a user AD object.

    using (var userObject = UserObject.FindOneByCN(this.ADOperator, “pangxiaoliang”))``
    {
         if(userObject.Email == "example@landpy.com")``
         {
              userObject.Email = "marketing@fewbox.com";``
              userObject.Save();``
         }
    }

E.G: Query user AD objects.

    // 1. CN end with "liu", Mail conatains "live" (Eg: marketing@fewbox.com),
    // job title is "Dev" and AD object type is user.
    // 2. CN start with "pang", Mail conatains "live" (Eg: marketing@fewbox.com),
    // job title is "Dev" and AD object type is user.
                IFilter filter =
                    new And(
                        new IsUser(),
                        new Contains(PersonAttributeNames.Mail, "live"),
                        new Is(PersonAttributeNames.Title, "Dev"),
                        new Or(
                                new StartWith(AttributeNames.CN, "pang"),
                                new EndWith(AttributeNames.CN, "liu")
                            )
                        );
    // Output the user object display name.
    foreach (var userObject in UserObject.FindAll(this.ADOperator, filter))
    {
        using (userObject)
        {
            Console.WriteLine(userObject.DisplayName);
        }
    }

E.G: Custom query.

    IFilter filter =
        new And(
            new IsUser(),
            new Custom("(!userAccountControl:1.2.840.113556.1.4.803:=2)")
            );
    // Output the user object display name.
    foreach (var userObject in UserObject.FindAll(this.ADOperator, filter))
    {
        using (userObject)
        {
            Console.WriteLine(userObject.DisplayName);
        }
    }
