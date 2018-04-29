using ChiakiBot.Utilities;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiakiBot.Modules
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        private TaskList tasks = new TaskList();

        [Command("readTasks")]
        public async Task ReadTaskList()
        {
            Task readfromfile = new Task(tasks.readFromFileAsync);
            readfromfile.Start();
            await readfromfile;
            await ReplyAsync("Completed reading tasks!");
        }

        [Command("createTask")]
        public async Task CreateTask(string date="Not Provided", string title="Not Provided", string description="Not Provided" )
        {
            tasks.createTask(date, title, description);
            await ReplyAsync("Added task!");

        }

        [Command("displayTasks")]
        public async Task DisplayTasks()
        {
            int counter = 0;
            EmbedBuilder builder = new EmbedBuilder();
            if (!TaskList._LoadedFromFile)
            {
                tasks.readFromFileAsync();
            }
            foreach (CustomEvents ce in TaskList._TaskList)
            {
                builder.WithTitle("**Title:** " + ce.EventTitle)
                    .WithDescription("**Date:           **"+ce.DueDateTime+"\n**Description:    **\n" + ce.EventDescription+ "\n**ID:             **" + counter++)
                    .WithColor(Color.DarkBlue);

                await ReplyAsync("", false, builder.Build());
            }
        }

        [Command("saveTasks")]
        public async Task SaveTasks()
        {
            Task saveToFile = new Task(tasks.writeToFileAsync);
            saveToFile.Start();
            await saveToFile;
            await ReplyAsync("Saved list of tasks to file!");
        }

        [Command("deleteTask")]
        public async Task DeleteTask(int index)
        {
            Boolean result = tasks.deleteTask(index);
            if (result)
                await ReplyAsync("Delete was successful");
            else
                await ReplyAsync("Something went wrong. Make sure that the id is valid.");
        }

        [Command("updateTask")]
        public async Task UpdateTask(int index, string date, string title, string description)
        {
            Boolean result = tasks.updateTask(index,date,title,description);
            if (result)
                await ReplyAsync("Update was successful");
            else
                await ReplyAsync("Something went wrong. Make sure that the id is valid.");
        }

        [Command("ping")]
        public async Task PingAsync()
        {
            await ReplyAsync("Hello World!");
        }
    }
}
