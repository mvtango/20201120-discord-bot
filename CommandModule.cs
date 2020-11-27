using Discord.Commands;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.Generic;

// from: https://docs.stillu.cc/guides/commands/intro.html
// Keep in mind your module **must** be public and inherit ModuleBase.
// If it isn't, it will not be discovered by AddModulesAsync!
public class EchoModule : ModuleBase<SocketCommandContext>
{
     // ~say hello world -> hello world
	[Command("say")]
	[Summary("Echoes a message.")]
	public Task SayAsync([Remainder] [Summary("The text to echo")] string echo)
		=> ReplyAsync("Echo " + echo + " " + echo);
		
	// ReplyAsync is a method on ModuleBase  
	[Command("lobe")]
	[Summary("lobt web auch immer ")]
	public Task PraiseAsync([Summary("The text to echo")] string name) {
        var sender = Context.Message.Author.Username;
        var response = "";
        var praises = new Dictionary<string, string>();

        praises.Add("niemanden", "Alle doof.");
        praises.Add("martin", "Hat er nicht verdient.");
        praises.Add("samuel", "Samuel ist einfach der Tollste.");
        praises.Add("dich", "Äh. Hm. Weiß nicht.");
        
        var who = praised(name);
        if (praises.TryGetValue(who.ToLower(), out response))
        {
            response = response + " Echt jetzt.";
        } else {
            if ( who == "mich" ) {
                response = $"{sender} ist sehr toll.";
            } else {
                response = $"{who} ist toll. Aber {sender} auch.";
            }
        }
		return ReplyAsync(response);
    }

    private string praised(string who) {
        var result = Regex.Replace(who, "[^ A-Za-z-]", "");
        return result;

    }

}
