using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalesPortal.Core.Models;

namespace SalesPortal.Core.Interfaces
{
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Pobierz obiekt
        /// </summary>
        /// <typeparam name="T">Typ zwracanego obiektu</typeparam>
        /// <param name="procedureName">nazwa procedury składowanej</param>
        /// <param name="obj">parametry wejściowe</param>
        /// <returns></returns>
        Result<T> FillObject<T>(string procedureName, object obj)  where T : class;

        /// <summary>
        /// Pobierz wartość skalarną
        /// </summary>
        /// <typeparam name="T">Typ zwracanego skalara</typeparam>
        /// <param name="procedureName">nazwa procedury składowanej</param>
        /// <param name="obj">parametry wejściowe</param>
        /// <returns></returns>
        Result<T> FillScalar<T>(string procedureName, object obj) where T : struct, IComparable, IFormattable, IConvertible;

        /// <summary>
        /// Pobierz wartość skalarną asynchronicznie
        /// </summary>
        /// <typeparam name="T">Typ zwracanego skalara</typeparam>
        /// <param name="procedureName">nazwa procedury składowanej</param>
        /// <param name="obj">parametry wejściowe</param>
        /// <returns></returns>
        Task<Result<T>> FillScalarAsync<T>(string procedureName, object obj) where T : struct, IComparable, IFormattable, IConvertible;

        /// <summary>
        /// Wykonaj modyfikację danych
        /// </summary>
        /// <typeparam name="T">Typ zwracanego komunikatu</typeparam>
        /// <typeparam name="TResultType">Enumerator komunikatu przetworzonego po stronie serwera danych</typeparam>
        /// <param name="procedureName">nazwa procedury składowanej</param>
        /// <param name="obj">parametry wejściowe</param>
        /// <returns></returns>
        Result<T, TResultType> ExecuteQuery<T, TResultType>(string procedureName, object obj) where TResultType : struct, IComparable, IFormattable, IConvertible;

        /// <summary>
        /// Wykonaj modyfikację danych asynchronicznie
        /// </summary>
        /// <typeparam name="T">Typ zwracanego komunikatu</typeparam>
        /// <typeparam name="TResultType">Enumerator komunikatu przetworzonego po stronie serwera danych</typeparam>
        /// <param name="procedureName">nazwa procedury składowanej</param>
        /// <param name="obj">parametry wejściowe</param>
        /// <returns></returns>
        Task<Result<T, TResultType>> ExecuteQueryAsync<T, TResultType>(string procedureName, object obj) where TResultType : struct, IComparable, IFormattable, IConvertible;

        /// <summary>
        /// Pobierz listę
        /// </summary>
        /// <typeparam name="T">Typ zwracanego obiektu</typeparam>
        /// <param name="procedureName">nazwa procedury składowanej</param>
        /// <param name="obj">parametry wejściowe</param>
        /// <returns></returns>
        Result<IEnumerable<T>> FillCollection<T>(string procedureName, object obj);

        /// <summary>
        /// Pobierz obiekt asynchronicznie
        /// </summary>
        /// <typeparam name="T">Typ zwracanego obiektu</typeparam>
        /// <param name="procedureName">nazwa procedury składowanej</param>
        /// <param name="obj">parametry wejściowe</param>
        /// <returns></returns>
        Task<Result<T>> FillObjectAsync<T>(string procedureName, object obj) where T : class;

        /// <summary>
        /// Pobierz listę asynchronicznie
        /// </summary>
        /// <typeparam name="T">Typ zwracanego obiektu</typeparam>
        /// <param name="procedureName">nazwa procedury składowanej</param>
        /// <param name="obj">parametry wejściowe</param>
        /// <returns></returns>
        Task<Result<IEnumerable<T>>> FillCollectionAsync<T>(string procedureName, object obj);
    }
}