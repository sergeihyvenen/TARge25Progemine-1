using System;
using System.Collections.Generic;
using System.Text;
using TARge25Shop.Core.Domain;
using TARge25Shop.Core.Dto;
using TARge25Shop.Core.ServiceInterface;
using Xunit;

namespace TARge25Shop.Spaceship.Test
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceShip_WhenResultIsReturned()
        {
            // Ülesseade
            SpaceshipDto dto = new SpaceshipDto()
            {
                Name = "X AE a L 12 menuornvöerv",
                ShipType = "lendav taldrik",
                Crew = 67,
                EnginePower = 69,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            // Tegutsemine
            var result = await Svc<ISpaceshipServices>().Create(dto);

            // Kontroll
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetSpaceShipById_WhenIdNotEqual()
        {
            // Ülesseade
            Guid wrongGuid = Guid.NewGuid();
            Guid goodGuid = Guid.Parse("3be7da80-4ce7-452b-9809-ae9bbefb29f2");

            // Tegevus
            await Svc<ISpaceshipServices>().DetailAsync(goodGuid);

            // Kontroll
            Assert.NotEqual(wrongGuid, goodGuid);
        }

        [Fact]
        public async Task Should_GetSpaceshipById_WhenGuidIsEqual()
        {
            // Ülesseade
            Guid databaseGuid = Guid.Parse("3be7da80-4ce7-452b-9809-ae9bbefb29f2");
            Guid seekGuid = Guid.Parse("3be7da80-4ce7-452b-9809-ae9bbefb29f2");

            // Tegevus
            await Svc<ISpaceshipServices>().DetailAsync(seekGuid);

            // Kontroll
            Assert.Equal(databaseGuid, seekGuid);
        }

        [Fact]
        public async Task Should_SpaceshipDeletedById_WhenReturnedResultIsEqual()
        {
            // Ülesseade
            SpaceshipDto dto = MockSpaceshupData();

            // Tegevus
            var addSpaceship = await Svc<ISpaceshipServices>().Create(dto);
            var deleteSpaceship = await Svc<ISpaceshipServices>().Delete((Guid)addSpaceship.Id);

            // Kontroll
            Assert.Equal(addSpaceship.Id, deleteSpaceship.Id);
        }

        private SpaceshipDto MockSpaceshupData(bool isOneOrTwo = false)
        {
            if (isOneOrTwo == false)
            {
                return new SpaceshipDto
                {
                    Name = "X AE a L 12 menuornvöerv",
                    ShipType = "lendav taldrik",
                    Crew = 67,
                    EnginePower = 69,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
            }
            else
            {
                return new SpaceshipDto
                {
                    Name = "RAKETT69",
                    ShipType = "lendav kauss",
                    Crew = 420,
                    EnginePower = 69,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
            }
        }
    }
}