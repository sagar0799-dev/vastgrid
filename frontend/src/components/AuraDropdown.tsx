import React, { useState, useRef, useEffect } from 'react';

interface DropdownOption {
  value: string | number;
  label: string;
  subLabel?: string;
}

interface AuraDropdownProps {
  options: DropdownOption[];
  value: string | number;
  onChange: (value: any) => void;
  placeholder: string;
  label: string;
  disabled?: boolean;
}

export const AuraDropdown: React.FC<AuraDropdownProps> = ({
  options,
  value,
  onChange,
  placeholder,
  label,
  disabled = false
}) => {
  const [isOpen, setIsOpen] = useState(false);
  const dropdownRef = useRef<HTMLDivElement>(null);

  const selectedOption = options.find(opt => opt.value === value);

  // Close dropdown when clicking outside
  useEffect(() => {
    const handleClickOutside = (event: MouseEvent) => {
      if (dropdownRef.current && !dropdownRef.current.contains(event.target as Node)) {
        setIsOpen(false);
      }
    };
    document.addEventListener('mousedown', handleClickOutside);
    return () => document.removeEventListener('mousedown', handleClickOutside);
  }, []);

  return (
    <div className="space-y-2 relative" ref={dropdownRef}>
      <label className="text-[10px] font-bold text-aura-primary uppercase tracking-widest ml-1">
        {label}
      </label>
      
      <button
        type="button"
        disabled={disabled}
        onClick={() => setIsOpen(!isOpen)}
        className={`w-full flex items-center justify-between bg-white/50 border-2 border-aura-border/30 rounded-2xl px-4 py-3 text-sm font-bold transition-all text-left ${
          isOpen ? 'border-aura-primary/50 shadow-aura-soft ring-4 ring-aura-primary/5' : 'hover:border-aura-primary/30'
        } ${disabled ? 'opacity-50 cursor-not-allowed' : 'cursor-pointer'}`}
      >
        <span className={selectedOption ? 'text-aura-text-primary' : 'text-aura-text-secondary/60'}>
          {selectedOption ? selectedOption.label : placeholder}
        </span>
        <svg 
          width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="3" strokeLinecap="round" strokeLinejoin="round"
          className={`text-aura-primary transition-transform duration-300 ${isOpen ? 'rotate-180' : ''}`}
        >
          <polyline points="6 9 12 15 18 9"></polyline>
        </svg>
      </button>

      {/* Options List */}
      {isOpen && !disabled && (
        <div className="absolute top-full left-0 w-full mt-2 z-[200] glass-panel rounded-2xl overflow-hidden border-2 border-white/50 shadow-2xl animate-in fade-in zoom-in-95 duration-200 origin-top">
          <div className="max-h-60 overflow-auto divide-y divide-aura-border/10">
            {options.map((option) => (
              <button
                key={option.value}
                type="button"
                onClick={() => {
                  onChange(option.value);
                  setIsOpen(false);
                }}
                className={`w-full text-left px-5 py-4 text-sm transition-colors group flex flex-col ${
                  value === option.value 
                    ? 'bg-aura-primary text-white' 
                    : 'text-aura-text-primary hover:bg-aura-primary/10'
                }`}
              >
                <span className="font-bold">{option.label}</span>
                {option.subLabel && (
                  <span className={`text-[10px] uppercase tracking-wider font-medium ${
                    value === option.value ? 'text-white/70' : 'text-aura-text-secondary'
                  }`}>
                    {option.subLabel}
                  </span>
                )}
              </button>
            ))}
            {options.length === 0 && (
              <div className="px-5 py-8 text-center text-xs text-aura-text-secondary italic">
                No options available
              </div>
            )}
          </div>
        </div>
      )}
    </div>
  );
};
