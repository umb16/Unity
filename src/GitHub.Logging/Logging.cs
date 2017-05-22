using System;

namespace GitHub.Unity
{
    class NullLogAdapter : LogAdapterBase
    {
        public NullLogAdapter() : base(null)
        {}

        protected override void OnInfo(string message)
        {
        }

        protected override void OnDebug(string message)
        {
        }

        protected override void OnTrace(string message)
        {
        }

        protected override void OnWarning(string message)
        {
        }

        protected override void OnError(string message)
        {
        }
    }

    public static class Logging
    {
        private static ILogging nullLogger = new NullLogAdapter();

        private static bool tracingEnabled;
        public static bool TracingEnabled
        {
            get
            {
                return tracingEnabled;
            }
            set
            {
                if (tracingEnabled != value)
                {
                    tracingEnabled = value;
                    Instance?.Info("Trace Logging " + (value ? "Enabled" : "Disabled"));
                }
            }
        }

        private static Func<string, ILogging> loggerFactory;
        public static Func<string, ILogging> LoggerFactory
        {
            get { return loggerFactory; }
            set { loggerFactory = value; }
        }

        private static ILogging instance;
        private static ILogging Instance
        {
            get {
                if (instance == null)
                {
                    instance = loggerFactory?.Invoke(null);
                }
                return instance;
            }
            set { instance = value; }
        }

        public static ILogging GetLogger<T>()
        {
            return GetLogger(typeof(T));
        }

        public static ILogging GetLogger(Type type)
        {
            return GetLogger(type.Name);
        }

        public static ILogging GetLogger(string context = null)
        {
            return loggerFactory?.Invoke(context) ?? nullLogger;
        }

        public static void Info(string s)
        {
            Instance?.Info(s);
        }

        public static void Debug(string s)
        {
            Instance?.Debug(s);
        }

        public static void Trace(string s)
        {
            Instance?.Trace(s);
        }

        public static void Warning(string s)
        {
            Instance?.Warning(s);
        }

        public static void Error(string s)
        {
            Instance?.Error(s);
        }

        public static void Info(string format, params object[] objects)
        {
            Instance?.Info(format, objects);
        }

        public static void Debug(string format, params object[] objects)
        {
            Instance?.Debug(format, objects);
        }

        public static void Trace(string format, params object[] objects)
        {
            Instance?.Trace(format, objects);
        }

        public static void Warning(string format, params object[] objects)
        {
            Instance?.Warning(format, objects);
        }

        public static void Error(string format, params object[] objects)
        {
            Instance?.Error(format, objects);
        }

        public static void Info(Exception ex, string s)
        {
            Instance?.Info(ex, s);
        }

        public static void Debug(Exception ex, string s)
        {
            Instance?.Debug(ex, s);
        }

        public static void Trace(Exception ex, string s)
        {
            Instance?.Trace(ex, s);
        }

        public static void Warning(Exception ex, string s)
        {
            Instance?.Warning(ex, s);
        }

        public static void Error(Exception ex, string s)
        {
            Instance?.Error(ex, s);
        }
    }
}