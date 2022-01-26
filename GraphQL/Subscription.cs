using CommanderGQL.Models;

namespace CommanderGQL.GraphQL
{
    /// <summary>
    /// Represents the subscriptions available.
    /// </summary>
    [GraphQLDescription("Represents the queries available.")]
    public class Subscription
    {
        /// <summary>
        /// The subscription for added <see cref="Platform"/>.
        /// </summary>
        /// <param name="platform">The <see cref="Platform"/>.</param>
        /// <returns>The added <see cref="Platform"/>.</returns>
        [Subscribe]
        [Topic]
        [GraphQLDescription("The subscription for added platform.")]
        public Platform OnPlatformAdded([EventMessage] Platform platform) =>  platform;

        /// <summary>
        /// The subscription for added <see cref="Command"/>.
        /// </summary>
        /// <param name="command">The <see cref="Command"/>.</param>
        /// <returns>The added <see cref="Command"/>.</returns>
        [Subscribe]
        [Topic]
        [GraphQLDescription("The subscription for added command.")]
        public Command OnCommandAdded([EventMessage] Command command) => command;

    }
}
