using Core.Entities;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository
{
    public class GymManagementSystemDataSeeding
    {
        public static async Task SeedAsync(GymManagementSystemDbContext dbContext)
        {
            /////////////////////////////////////////////////////////////////////////
            // Branches

            if (!dbContext.Branches.Any())
            {
                var branchesData = File.ReadAllText("../Repository/DataSeed/branches.json");
                var branches = JsonSerializer.Deserialize<List<Branch>>(branchesData);
                if (branches?.Count > 0)
                {
                    foreach (var branch in branches)
                    {
                        await dbContext.Branches.AddAsync(branch);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }


            /////////////////////////////////////////////////////////////////////////
            // MembershipPlans

            if (!dbContext.MembershipPlans.Any())
            {
                var membershipPlansData = File.ReadAllText("../Repository/DataSeed/membershipplans.json");
                var membershipPlans = JsonSerializer.Deserialize<List<MembershipPlan>>(membershipPlansData);
                if(membershipPlans?.Count > 0)
                {
                    foreach(var membershipPlan in membershipPlans)
                    {
                        await dbContext.MembershipPlans.AddAsync(membershipPlan);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }


            /////////////////////////////////////////////////////////////////////////
            // Trainers

            if (!dbContext.Trainers.Any())
            {
                var trainersData = File.ReadAllText("../Repository/DataSeed/trainers.json");
                var trainers = JsonSerializer.Deserialize<List<Trainer>>(trainersData);
                if (trainers?.Count > 0)
                {
                    foreach (var trainer in trainers)
                    {
                        trainer.PasswordHash = BCrypt.Net.BCrypt.HashPassword(trainer.PasswordHash);
                        await dbContext.Trainers.AddAsync(trainer);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }


            /////////////////////////////////////////////////////////////////////////
            // Members

            if (!dbContext.Members.Any())
            {
                var membersData = File.ReadAllText("../Repository/DataSeed/members.json");
                var members = JsonSerializer.Deserialize<List<Member>>(membersData);
                if (members?.Count > 0)
                {
                    foreach (var member in members)
                    {
                        member.PaswordHash = BCrypt.Net.BCrypt.HashPassword(member.PaswordHash);
                        await dbContext.Members.AddAsync(member);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }


            /////////////////////////////////////////////////////////////////////////
            // FitnessClasses

            if (!dbContext.FitnessClasses.Any())
            {
                var fitnessClassesData = File.ReadAllText("../Repository/DataSeed/fitnessclasses.json");
                var fitnessclasses = JsonSerializer.Deserialize<List<FitnessClass>>(fitnessClassesData);
                if (fitnessclasses?.Count > 0)
                {
                    foreach (var fitnessclass in fitnessclasses)
                    {
                        await dbContext.FitnessClasses.AddAsync(fitnessclass);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }


            /////////////////////////////////////////////////////////////////////////
            // MembershipSubscriptions

            if (!dbContext.MembershipSubscriptions.Any())
            {
                var membershipSubscriptionsData = File.ReadAllText("../Repository/DataSeed/membershipsubscriptions.json");
                var membershipSubscriptions = JsonSerializer.Deserialize<List<MembershipSubscription>>(membershipSubscriptionsData);
                if (membershipSubscriptions?.Count > 0)
                {
                    foreach (var membershipSubscription in membershipSubscriptions)
                    {
                        await dbContext.MembershipSubscriptions.AddAsync(membershipSubscription);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }


            /////////////////////////////////////////////////////////////////////////
            // AttendenceRecords

            if (!dbContext.AttendenceRecords.Any())
            {
                var attendenceRecordsData = File.ReadAllText("../Repository/DataSeed/attendencerecords.json");
                var attendenceRecords = JsonSerializer.Deserialize<List<AttendenceRecord>>(attendenceRecordsData);
                if (attendenceRecords?.Count > 0)
                {
                    foreach (var attendenceRecord in attendenceRecords)
                    {
                        await dbContext.AttendenceRecords.AddAsync(attendenceRecord);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }


            /////////////////////////////////////////////////////////////////////////
            // Payments

            if (!dbContext.Payments.Any())
            {
                var paymentsData = File.ReadAllText("../Repository/DataSeed/payments.json");
                var payments = JsonSerializer.Deserialize<List<Payment>>(paymentsData);
                if (payments?.Count > 0)
                {
                    foreach (var payment in payments)
                    {
                        await dbContext.Payments.AddAsync(payment);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }


            /////////////////////////////////////////////////////////////////////////
            // Reviews

            if (!dbContext.Reviews.Any())
            {
                var reviewsData = File.ReadAllText("../Repository/DataSeed/reviews.json");
                var reviews = JsonSerializer.Deserialize<List<Review>>(reviewsData);
                if (reviews?.Count > 0)
                {
                    foreach (var review in reviews)
                    {
                        await dbContext.Reviews.AddAsync(review);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

        }
    }
}
