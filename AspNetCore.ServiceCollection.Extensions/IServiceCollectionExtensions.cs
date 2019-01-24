using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.Extensions.Configuration.ServiceCollection
{
    /// <summary>
    /// Strongly typed configuration without IOptions&lt;T&gt;.
    /// </summary>
    public static class IServiceCollectionExtentions
    {
        /// <summary>
        /// Registers a configuration instance which TConfig will bind against.
        /// </summary>
        /// <returns>The POCO.</returns>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        /// <typeparam name="TConfig">The 1st type parameter.</typeparam>
        public static IServiceCollection ConfigurePoco<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var config = new TConfig();
            configuration.Bind(config);
            return services.AddSingleton(config);
        }

        /// <summary>
        /// Registers a configuration instance which TConfig will bind against.
        /// </summary>
        /// <returns>The POCO.</returns>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        /// <param name="customProvider">Custom provider.</param>
        /// <typeparam name="TConfig">The 1st type parameter.</typeparam>
        public static IServiceCollection ConfigurePoco<TConfig>(this IServiceCollection services, IConfiguration configuration, Func<TConfig> customProvider) where TConfig : class
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (customProvider == null) throw new ArgumentNullException(nameof(customProvider));

            var config = customProvider;
            configuration.Bind(config);
            return services.AddSingleton(config);
        }

        /// <summary>
        /// Registers a configuration instance which TConfig will bind against.
        /// </summary>
        /// <returns>The POCO.</returns>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        /// <param name="config">Config.</param>
        /// <typeparam name="TConfig">The 1st type parameter.</typeparam>
        public static IServiceCollection ConfigurePoco<TConfig>(this IServiceCollection services, IConfiguration configuration, TConfig config) where TConfig : class
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (config == null) throw new ArgumentNullException(nameof(config));

            configuration.Bind(config);
            return services.AddSingleton(config);
        }
    }
}
