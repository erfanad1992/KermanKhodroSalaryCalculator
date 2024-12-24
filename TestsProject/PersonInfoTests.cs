using Domain.PersonInfos;
using FluentAssertions;
using Xunit;

namespace TestsProject
{
    public class PersonInfoTests
    {
        [Fact]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            long id = 1;
            string name = "erfan";
            string family = "darvishniya";
            DateTimeOffset date = DateTimeOffset.UtcNow;
            decimal basicSalary = 5000;
            decimal allowance = 2000;
            decimal transportation = 300;
            decimal salaryAfterTax = 6200;

            // Act
            var person = new PersonInfo(id, name, family, date, basicSalary, allowance, transportation, salaryAfterTax);

            // Assert
            person.Id.Should().Be(id);
            person.Name.Should().Be(name);
            person.Family.Should().Be(family);
            person.Date.Should().Be(date);
            person.BasicSalary.Should().Be(basicSalary);
            person.Allowance.Should().Be(allowance);
            person.Transportation.Should().Be(transportation);
            person.SalaryAfterTax.Should().Be(salaryAfterTax);
        }

        [Fact]
        public void Update_ShouldUpdatePropertiesCorrectly()
        {
            // Arrange
            var person = new PersonInfo(1, "erfan", "darvishniya", DateTimeOffset.UtcNow, 5000, 2000, 300, 6200);

            string updatedName = "abbas";
            string updatedFamily = "darvish";
            DateTimeOffset updatedDate = DateTimeOffset.UtcNow.AddDays(1);
            decimal updatedBasicSalary = 5500;
            decimal updatedAllowance = 2500;
            decimal updatedTransportation = 400;
            decimal updatedSalaryAfterTax = 7100;

            // Act
            person.Update(updatedName, updatedFamily, updatedDate, updatedBasicSalary, updatedAllowance, updatedTransportation, updatedSalaryAfterTax);

            // Assert
            person.Name.Should().Be(updatedName);
            person.Family.Should().Be(updatedFamily);
            person.Date.Should().Be(updatedDate);
            person.BasicSalary.Should().Be(updatedBasicSalary);
            person.Allowance.Should().Be(updatedAllowance);
            person.Transportation.Should().Be(updatedTransportation);
            person.SalaryAfterTax.Should().Be(updatedSalaryAfterTax);
        }

        [Fact]
        public void Id_ShouldRemainUnchanged_AfterUpdate()
        {
            // Arrange
            var person = new PersonInfo(1, "erfan", "darvishniya", DateTimeOffset.UtcNow, 5000, 2000, 300, 6200);

            // Act
            person.Update("emran", "darvish", DateTimeOffset.UtcNow, 5500, 2500, 400, 7100);

            // Assert
            person.Id.Should().Be(1); // Id should not change
        }

        [Fact]
        public void PrivateConstructor_ShouldBeInaccessible()
        {
            // Act & Assert
            typeof(PersonInfo).GetConstructors(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Should().HaveCount(1, "There should be only one private constructor");
        }
    }
}
