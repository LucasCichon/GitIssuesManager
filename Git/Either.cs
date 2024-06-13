using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Git
{

public abstract class Either<TLeft, TResult>
    {
        public abstract bool IsLeft { get; }
        public abstract bool IsRight { get; }

        public abstract TLeft Left { get; }
        public abstract TResult Right { get; }

        public static Either<TLeft, TResult> CreateLeft(TLeft left)
        {
            return new LeftEither<TLeft, TResult>(left);
        }

        public static Either<TLeft, TResult> CreateRight(TResult right)
        {
            return new RightEither<TLeft, TResult>(right);
        }
    }

    public sealed class LeftEither<TLeft, TRight> : Either<TLeft, TRight>
    {
        private readonly TLeft _value;

        public LeftEither(TLeft value)
        {
            _value = value;
        }

        public override bool IsLeft => true;
        public override bool IsRight => false;
        public override TLeft Left => _value;
        public override TRight Right => throw new InvalidOperationException("No right value present");
    }

    public sealed class RightEither<TLeft, TRight> : Either<TLeft, TRight>
    {
        private readonly TRight _value;

        public RightEither(TRight value)
        {
            _value = value;
        }

        public override bool IsLeft => false;
        public override bool IsRight => true;
        public override TLeft Left => throw new InvalidOperationException("No left value present");
        public override TRight Right => _value;
    }

    public static class EitherExtensions
    {
        public static Either<TLeft, TRightResult> Map<TLeft, TRight, TRightResult>(
            this Either<TLeft, TRight> either,
            Func<TRight, TRightResult> mapFunc)
        {
            return either.IsRight
                ? Either<TLeft, TRightResult>.CreateRight(mapFunc(either.Right))
                : Either<TLeft, TRightResult>.CreateLeft(either.Left);
        }

        public static void Match<TLeft, TRight>(this Either<TLeft, TRight> either, Action<TRight> onRight, Action<TLeft> onLeft)
        {
            if (either.IsRight)
            {
                onRight(either.Right);
            }
            else
            {
                onLeft(either.Left);
            }
        }

        public static Either<TLeft, TRightResult> Bind<TLeft, TRight, TRightResult>(
            this Either<TLeft, TRight> either,
            Func<TRight, Either<TLeft, TRightResult>> bindFunc)
        {
            return either.IsRight
                ? bindFunc(either.Right)
                : Either<TLeft, TRightResult>.CreateLeft(either.Left);
        }
    }
}
