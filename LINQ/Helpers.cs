namespace Structure
{
    class Program
    {
        private static void Main(string[] args)
        {
            
        }
    }
    static class Helpers
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Predicate<T> func)
        {
            foreach (var item in list)
            {

                if (!func(item)) yield break;

                yield return item;               
            }
        }
        
        public static IEnumerable<T> Skip<T>(this IEnumerable<T> list, int count)
        {
            int current = 0;
            foreach (var item in list)
            {

                if (current >= count)
                {
                    yield return item;
                }
                else
                {
                    current++;
                }

                
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> list, Predicate<T> func)
        {
            bool matched = false;
            foreach (var item in list)
            {

                if (!matched)
                {
                    matched = func(item);
                }
                
                if (matched)
                {
                    yield return item;
                } else
                {
                    yield break;
                }
            }
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> list, int count)
        {
            int current = 0;
            foreach (var item in list)
            {

                if (current >= count) yield break;

                yield return item;
                current++;
            }
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> list, Predicate<T> func)
        {
            bool matched = true;
            foreach (var item in list)
            {

                if (matched)
                {
                    matched = func(item);

                    if (matched)
                    {
                        yield return item;
                    }
                } else
                {
                    yield break;
                }
            }
        }

        public static IEnumerable<T> FirstLastItem<T>(this IEnumerable<T> list, int index)
        {
            if (list == null || list.Count() == 0)
            {
                throw new ArgumentException("List is empty or null");
            }

            int current = 0;
            foreach (var item in list)
            {

                if (current != index) yield break;

                yield return item;
                current++;
            }
        }

        public static IEnumerable<T> First<T>(this IEnumerable<T> list)
        {
            yield return (T)FirstLastItem<T>(list, 0);
        }

        public static IEnumerable<T>? FirstOrDefault<T>(this IEnumerable<T> list)
        {
            if (list == null || list.Count() == 0)
            {
                yield return default(T);
            }

            yield return (T)First<T>(list);
        }

        public static IEnumerable<T> Last<T>(this IEnumerable<T> list)
        {
            yield return (T)FirstLastItem<T>(list, list.Count());
        }

        public static IEnumerable<T>? LastOrDefault<T>(this IEnumerable<T> list)
        {
            if (list == null || list.Count() == 0)
            {
                yield return default(T);
            }

            yield return (T)Last<T>(list);
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException("Source or selector is null");
            }

            return SelectIterator(source, selector);
        }

        private static IEnumerable<TResult> SelectIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            int index = -1;
            foreach (TSource element in source)
            {
                checked
                {
                    index++;
                }

                yield return selector(element, index);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException("Source or selector is null");
            }

            return SelectManyIterator(source, selector);
        }

        private static IEnumerable<TResult> SelectManyIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
        {
            int index = -1;
            foreach (TSource element in source)
            {
                checked
                {
                    index++;
                }

                foreach (TResult subElement in selector(element, index))
                {
                    yield return subElement;
                }
            }
        }

        public static bool Any<T>(this IEnumerable<T> list)
        {
            return list.Count() > 0;
        }
        
        public static bool Any<T>(this IEnumerable<T> list, Predicate<T> func)
        {
            foreach (var item in list)
            {
                if (func(item)) return true;
            }
            return false;
        }

        public static bool All<T>(this IEnumerable<T> list, Predicate<T> func)
        {
            foreach (var item in list)
            {
                if (!func(item)) return false;
            }

            return true;
        }

        public static T[] ToArray<T>(this IEnumerable<T> list)
        {
            return list.ToArray();
        }

        public static Library.List<T> ToList<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source is null");
            }

            return new Library.List<T>(source);
        }
    }
}
