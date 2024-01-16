using Kitchen.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Context.Contracts
{
    public interface IKitchenContext
    {
        /// <summary>Список <inheritdoc cref="Cuisine"/></summary>
        DbSet<Cuisine> Cuisines { get; }

        /// <summary>Список <inheritdoc cref="Post"/></summary>
        DbSet<Post> Posts { get; }

        /// <summary>Список <inheritdoc cref="Staff"/></summary>
        DbSet<Staff> Staffs { get; }

        /// <summary>Список <inheritdoc cref="Stimulation"/></summary>
        DbSet<Stimulation> Stimulations { get; }

        /// <summary>Список <inheritdoc cref="TypeOfTurnout"/></summary>
        DbSet<TypeOfTurnout> TypeOfTurnouts { get; }

        /// <summary>Список <inheritdoc cref="TurnOut"/></summary>
        DbSet<TurnOut> TurnOuts { get; }
    }
}
