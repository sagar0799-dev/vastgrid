// ============================================================================
// AuraHome & VastGrid Frontend Logger Utility
// Enforces structured logging with custom colors, timestamps, and log levels.
// ============================================================================

export type LogLevel = 'DEBUG' | 'INFO' | 'WARN' | 'ERROR';

class Logger {
  private context: string;

  constructor(context: string) {
    this.context = context;
  }

  /**
   * Generates CSS styles for the browser console based on the log level.
   */
  private getStyles(level: LogLevel): { prefix: string; text: string } {
    switch (level) {
      case 'DEBUG':
        return {
          prefix: 'background: #64748b; color: white; padding: 2px 5px; border-radius: 3px; font-weight: bold;',
          text: 'color: #64748b; font-weight: normal;'
        };
      case 'INFO':
        return {
          prefix: 'background: #0284c7; color: white; padding: 2px 5px; border-radius: 3px; font-weight: bold;',
          text: 'color: #0f172a; font-weight: normal;'
        };
      case 'WARN':
        return {
          prefix: 'background: #ea580c; color: white; padding: 2px 5px; border-radius: 3px; font-weight: bold;',
          text: 'color: #ea580c; font-weight: 500;'
        };
      case 'ERROR':
        return {
          prefix: 'background: #dc2626; color: white; padding: 2px 5px; border-radius: 3px; font-weight: bold;',
          text: 'color: #dc2626; font-weight: bold;'
        };
    }
  }

  /**
   * Formats the log message print layout.
   */
  private print(level: LogLevel, message: string, data?: any) {
    const timestamp = new Date().toLocaleTimeString([], { hour12: false });
    const styles = this.getStyles(level);

    if (data !== undefined) {
      console.groupCollapsed(
        `%c${level}%c [${timestamp}] [${this.context}]: ${message}`,
        styles.prefix,
        styles.text
      );
      console.log('Context Payload:', data);
      console.groupEnd();
    } else {
      console.log(
        `%c${level}%c [${timestamp}] [${this.context}]: ${message}`,
        styles.prefix,
        styles.text
      );
    }
  }

  /**
   * DEBUG: Technical/system trace logs. Hidden in production.
   */
  debug(message: string, data?: any) {
    if (import.meta.env.DEV) {
      this.print('DEBUG', message, data);
    }
  }

  /**
   * INFO: Standard user interactions and state handshakes.
   */
  info(message: string, data?: any) {
    this.print('INFO', message, data);
  }

  /**
   * WARN: Potential hazard warnings, incorrect user attempts, retry mechanisms.
   */
  warn(message: string, data?: any) {
    this.print('WARN', message, data);
  }

  /**
   * ERROR: Failures, boundary errors, or system-denied actions.
   */
  error(message: string, data?: any) {
    this.print('ERROR', message, data);
  }
}

export const createLogger = (context: string) => new Logger(context);
